package hello

//https://blog.golang.org/using-go-modules

import (
	"rsc.io/quote/v3"
	// quotev3 "rsc.io/quote/v3"
)

// Hello world test
func Hello() string {
	return quote.HelloV3()
}

// Proverb returns a proverb
func Proverb() string {
	return quote.Concurrency()
}
