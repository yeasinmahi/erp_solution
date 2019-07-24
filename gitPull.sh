#!/bin/bash

repos=( 
  ${PWD}
)

echo ""
echo "Getting latest for" ${#repos[@]} "repositories using pull --rebase"

for repo in "${repos[@]}"
do
  echo ""
  echo "****** Getting latest for" ${repo} "******"
  cd "${repo}"
  git pull --rebase
  echo "******************************************"
  read -t 15 -n 1
done
