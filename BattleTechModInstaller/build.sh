#!/bin/bash

# run using git bash console
set -ex

# prepare mods
cd mods

MODS="CptMoore/SpeedMod CptMoore/HardpointFixMod CptMoore/StatsFixMod CptMoore/StartingMercsMod hokvel/pansar"

for MODPATH in $MODS
do
	MODNAME=$(basename "$MODPATH")
	rm -fr "$MODNAME"
	git clone --depth=1 --branch=master "https://github.com/${MODPATH}.git" "${MODNAME}"
	rm -rf "${MODNAME}/.git"
done

# get latest of all repos
# compile them all
#cd ..
#devenv /build Release BattleTechModTools.sln
