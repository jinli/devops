package main

import (
	"fmt"
)

/*
* References:
* https://blog.golang.org/pipelines

*
 */

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
func findMedianSortedArrays(nums1 []int, nums2 []int) float64 {
	p1, p2 := 0, 0

	mergeNext := func() int {
		var nextNum int
		if p1 < len(nums1) && p2 < len(nums2) {
			if nums1[p1] <= nums2[p2] {
				nextNum = nums1[p1]
				p1++
			} else {
				nextNum = nums2[p2]
				p2++
			}
		} else if p1 == len(nums1) {
			nextNum = nums1[p1]
			p1++
		} else if p2 == len(nums2) {
			nextNum = nums2[p2]
			p2++
		}

		return nextNum
	}

	avg := mergeNext()
	fmt.Println(avg)

	return float64(avg)
}

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

	// err := filepath.Walk(".",
	// 	func(path string, info os.FileInfo, err error) error {
	// 		if err != nil {
	// 			return err
	// 		}
	// 		fmt.Println(path, info.Size())
	// 		return nil
	// 	})

	// if err != nil {
	// 	log.Println(err)
	// }

	// var str string

	// str = `{"page": 1, "fruits": ["apple", "peach"]}`

	// var js interface{}
	// err := json.Unmarshal([]byte(str), &js)

	// if err == nil {
	// 	fmt.Println(js)
	// }

	// fmt.Println("string")
	// fmt.Println(reflect.TypeOf(js))

	var (
		m int
		n int
	)

	m = 0
	n = 1
	avg := (m + n) / 2
	mm := (m + n) % 2

	avg1 := float64(m+n) * 0.5

	pos := [2]int{0, 0}

	fmt.Println(avg, mm, avg1)

	pos[0]++
	fmt.Println(pos[0] + pos[1])
}
