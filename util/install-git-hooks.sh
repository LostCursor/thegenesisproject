#!/bin/sh

SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ $SOURCE != /* ]] && SOURCE="$DIR/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done
SCRIPT_DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

HOOK_DIR=$SCRIPT_DIR/../.git/hooks

echo "Installing Git hooks to $HOOK_DIR"

for hook in $SCRIPT_DIR/git/hooks/*; do
    echo "  Installing hook $(basename $hook)"
    ln -s -f $hook $HOOK_DIR/$(basename $hook)
done
