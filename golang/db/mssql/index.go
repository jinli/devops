package main

import (
	"database/sql"
	"fmt"
	"log"
	"time"

	_ "github.com/denisenkom/go-mssqldb"
)

const (
	// connection string in  URL format
	// connStr = "sqlserver://user:pwd@eemdbserver?database=dbName"
	// connection string in ADO key value pair format
	connStr = "server=eemdbserver;user id=IONEEM;password=IONisgreat!;database=ION_EEMData"
)

func printValue(pval *interface{}) {
	switch v := (*pval).(type) {
	case nil:
		fmt.Print("NULL")
	case bool:
		if v {
			fmt.Print("1")
		} else {
			fmt.Print("0")
		}
	case []byte:
		fmt.Print(string(v))
	case time.Time:
		fmt.Print(v.Format("2006-01-02 15:04:05.999"))
	default:
		fmt.Print(v)
	}
}

func main() {

	db, err := sql.Open("sqlserver", connStr)

	if err != nil {
		log.Fatal("Open connection failed:", err.Error())
	}
	defer db.Close()

	rows, err := db.Query("select top 20 * from EEM_DataLog")
	if err != nil {
		log.Fatal(err)
	}
	defer rows.Close()

	cols, err := rows.Columns()
	if err != nil {
		log.Fatal(err)
	}

	for i := 0; i < len(cols); i++ {
		fmt.Println(cols[i])
	}

	vals := make([]interface{}, len(cols))

	for i := 0; i < len(cols); i++ {
		// another option is to use sql.RawBytes
		vals[i] = new(interface{})
		if i != 0 {
			fmt.Print("\t")
		}
		fmt.Print(cols[i])
	}
	fmt.Println()

	for rows.Next() {
		err = rows.Scan(vals...)
		if err != nil {
			fmt.Println(err)
			continue
		}

		for i := 0; i < len(vals); i++ {
			if i != 0 {
				fmt.Print("\t")
			}

			printValue(vals[i].(*interface{}))
		}
		fmt.Println()
	}
}
