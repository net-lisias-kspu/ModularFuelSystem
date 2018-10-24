#!/usr/bin/env bash

check() {
	if [ ! -d "./GameData/$TARGETBINDIR/" ] ; then
		rm -f "./GameData/$TARGETBINDIR/"
		mkdir -p "./GameData/$TARGETBINDIR/"
	fi
}

deploy_dev() {
	local DLL=$1

	if [ -f "./bin/Release/$DLL.dll" ] ; then
		cp "./bin/Release/$DLL.dll" "$LIB"
	fi
}

deploy_bin() {
	local DLL=$1

	if [ -f "./bin/Release/$DLL.dll" ] ; then
		cp "./bin/Release/$DLL.dll" "./GameData/$TARGETBINDIR/"
		if [ -d "${KSP_DEV}/GameData/$TARGETBINDIR/" ] ; then
			cp "./bin/Release/$DLL.dll" "${KSP_DEV/}GameData/$TARGETBINDIR/"
		fi
	fi
	if [ -f "./bin/Debug/$DLL.dll" ] ; then
		if [ -d "${KSP_DEV}/GameData/$TARGETBINDIR/" ] ; then
			cp "./bin/Debug/$DLL.dll" "${KSP_DEV}GameData/$TARGETBINDIR/"
		fi
	fi
}

deploy_md() {
	local MD=$1
	#![NxMyyTK.png](./PR_material/img/NxMyyTK.png)
	sed $MD -e "s/!\\[.\+\\]\\(.\+\\)//g" > "./GameData/$TARGETDIR"/$MD
}

deploy() {
	VERSIONFILE=$PACKAGE.version
	check
	cp $VERSIONFILE "./GameData/$TARGETDIR"
	cp CHANGE_LOG.md "./GameData/$TARGETDIR"
	cp *LICENSE "./GameData/$TARGETDIR"
	cp NOTICE "./GameData/$TARGETDIR"
	deploy_md README.md

	for dll in $* ; do
#		deploy_dev $dll
		deploy_bin $dll
	done
}


source ./CONFIG.mft.inc
deploy Scale_Redist $PACKAGE TweakScale_$PACKAGE

source ./CONFIG.rf.inc
deploy Scale_Redist $PACKAGE TweakScale_$PACKAGE TestFlightRF
