#!/usr/bin/env bash

#TODO: Cook a way to handle both derivatives! Right now, manual intervention to delete alien artifacts is needed.
source ./CONFIG.inc

clean() {
	rm $FILE
	if [ ! -d Archive ] ; then
		rm -f Archive
		mkdir Archive
	fi
}

FILE=$PACKAGE-$VERSION.zip
echo $FILE
clean
zip -r $FILE ./GameData/* -x ".*"
zip -r $FILE ./PluginData/* -x ".*"
zip -d $FILE __MACOSX "**/.DS_Store"
mv $FILE ./Archive
