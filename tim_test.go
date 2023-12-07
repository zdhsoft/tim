// Copyright (c) 2023, donnie <donnie4w@gmail.com>
// All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.
//
// github.com/donnie4w/tim
package main

import (
	"github.com/donnie4w/simplelog/logging"
	_ "github.com/donnie4w/tim/data"
	_ "github.com/donnie4w/tim/keystore"
	_ "github.com/donnie4w/tim/level1"
	_ "github.com/donnie4w/tim/service"
	_ "github.com/donnie4w/tim/tc"
	_ "github.com/donnie4w/tim/timnet"
)

func Test_main() {
	logging.Debug("tim start")
}
