package main

import (
	"fmt"
	"log"
	"os"
	"path/filepath"
)

// type Person struct {
// 	Name    string
// 	Age     int
// 	Address string
// 	DOB     time.Time `json:"dob"`
// 	ch      <-chan time.Time
// }

// type Direction int

// const (
// 	North Direction = iota
// 	East
// 	South
// 	West
// )

// func (d Direction) String() string {
// 	return [...]string{"North", "East", "South", "West"}[d]
// }

func main() {
	// t, ok := time.Parse(time.RFC3339, "1970-04-07T17:00:00Z")
	// fmt.Println(ok)
	// p := Person{
	// 	"Jin",
	// 	50,
	// 	"4304 Faithwood",
	// 	t,
	// }

	// jsonData, _ := json.Marshal(p)
	// fmt.Println(string(jsonData))

	// // t, _ := time.Parse("2006-01-02", "1999-09-10")
	// // fmt.Println(t.Format("January 2, 2006"))

	// fmt.Println(time.Now())

	// var ch <-chan time.Time

	// fmt.Println(ch)

	// location, err := time.LoadLocation("Asia/Shanghai")
	// if err != nil {
	// 	panic(err)
	// }

	// fmt.Println(location)

	// timeInUTC := time.Date(2018, 12, 30, 12, 0, 0, 0, time.UTC)
	// fmt.Println(timeInUTC.In(location))

	// fmt.Println(timeInUTC.ISOWeek())

	err := filepath.Walk(".",
		func(path string, info os.FileInfo, err error) error {
			if err != nil {
				return err
			}
			fmt.Println(path, info.Size())
			return nil
		})

	if err != nil {
		log.Println(err)
	}
}
