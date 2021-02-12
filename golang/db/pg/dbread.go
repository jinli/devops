package main

import (
	"database/sql"
	"fmt"
	"log"

	_ "github.com/lib/pq"
)

func main() {
	connStr := "host=dbs.westus2.cloudapp.azure.com user=u password=p! dbname=elearning"

	db, err := sql.Open("postgres", connStr)
	if err != nil {
		log.Fatal(err)
	}

	fmt.Println("connected")

	rows, err := db.Query("select id, name from permission")
	if err != nil {
		log.Fatal(err)
	}

	defer rows.Close()
	defer db.Close()
	fmt.Println("queried")

	for rows.Next() {
		var (
			id   int
			name string
		)
		if err := rows.Scan(&id, &name); err != nil {
			log.Fatal(err)
		}
		fmt.Printf("id %d name is %s\n", id, name)
	}
}
