#!/bin/sh

# run using git bash console

set -ex

# prepare mods
cd mods

MODS="SpeedMod HardpointFixMod StatsFixMod"

for MOD in $MODS
do
	rm -fr "$MOD"
	git clone --depth=1 --branch=master "https://github.com/CptMoore/${MOD}.git" "${MOD}"
	rm -rf "${MOD}/.git"
done

# get latest of all repos
# compile them all
#cd ..
#devenv /build Release BattleTechModTools.sln
