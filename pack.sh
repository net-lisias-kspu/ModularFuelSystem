#!/usr/bin/env bash

clean() {
	rm -f *.zip
	if [ ! -d Archive ] ; then
		rm -f Archive
		mkdir Archive
	fi
}

pack() {
    local FILE=$PACKAGE-$VERSION.zip
    echo $FILE
    zip -r $FILE ./GameData/$PACKAGE/* -x ".*"
    zip -r $FILE ./PluginData/* -x ".*"
    zip $FILE ./INSTALL.md
    zip -d $FILE __MACOSX "**/.DS_Store"
    mv $FILE ./Archive
}

clean

source ./CONFIG.mft.inc
pack

source ./CONFIG.rf.inc
pack
