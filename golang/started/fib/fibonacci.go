package main

import "fmt"

func fibonacci() func() int {
	n1, n2 := 0, 1
	return func() int {
		res := n1
		n1, n2 = n2, n1+n2
		return res

		// alternative:
		// n1, n2 = n2, n1+n2
		// return n2 - n1
	}
}

func main() {
	fib := fibonacci()
	for i := 0; i < 20; i++ {
		fmt.Println(fib())
	}
}
