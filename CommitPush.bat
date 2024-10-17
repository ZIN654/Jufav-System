@echo off
echo Please Set the name of commit
set /P str1=
git add .
git commit -m "%str1%"
git push -f origin main
echo Git Commit/Push is successfully executed
PAUSE