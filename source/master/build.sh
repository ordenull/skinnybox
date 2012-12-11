#!/bin/bash

function get_version() {
	# $1 = package name
   	_RET_=$(cat $1/DEBIAN/control | grep "^Version:" |  awk -F': ' '{print $2}')
}

function build_package() {
	# $1 = package name
	get_version "$1"
	version=$_RET_
	dpkg-deb --build $1 ../packages/$1-$version.deb
}

build_package "overlay"
build_package "automator"
