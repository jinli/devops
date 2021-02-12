package main

import (
	"context"
	"fmt"
	"log"

	"github.com/jackc/pgx/v4/pgxpool"
)

func main() {

	dbpool, err := pgxpool.Connect(context.Background(), "postgres://user:pwd@dbs.westus2.cloudapp.azure.com:5432/elearning")
	if err != nil {
		log.Fatal(err)
	}
	fmt.Println("connected")
	defer dbpool.Close()
	var (
		id   int
		name string
	)
	fmt.Println("query...")
	err = dbpool.QueryRow(context.Background(), "select id,name from permission limit 1").Scan(&id, &name)
	if err != nil {
		log.Fatal(err)
	}
	fmt.Println("done")
	fmt.Println(id, name)
}
