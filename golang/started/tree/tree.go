package main

import (
	"fmt"

	"golang.org/x/tour/tree"
)

// Walk walks the tree t sending all values
// from the tree to the channel ch.
func Walk(root, t *tree.Tree, ch, quit chan int) {
	if t == nil {
		return
	}

	Walk(root, t.Left, ch, quit)

	select {
	case ch <- t.Value:
	case <-quit:
		fmt.Println("quit")
		close(ch)
		return
	}

	Walk(root, t.Right, ch, quit)

	if t == root {
		fmt.Println("done")
		close(ch)
	}
}

// Same determines whether the trees
// t1 and t2 contain the same values.
func Same(t1, t2 *tree.Tree) bool {
	ch1, ch2, quit := make(chan int), make(chan int), make(chan int)

	go Walk(t1, t1, ch1, quit)
	go Walk(t2, t2, ch2, quit)

	result := true
	for {
		v1, ok1 := <-ch1
		v2, ok2 := <-ch2

		if v1 != v2 || ok1 != ok2 {
			result = false
			break
		}

		if !ok1 || !ok2 {
			break
		}
	}

	close(quit)

	return result
}

func main() {
	t1 := tree.New(1)
	t2 := tree.New(1)

	comp := Same(t1, t2)

	fmt.Println(comp)

	// ch := make(chan int)
	// quit := make(chan int)

	// root := tree.New(1)
	// go Walk(root, root, ch, quit)

	// for i := range ch {
	// 	fmt.Println(i)
	// }
	// close(quit)
}
