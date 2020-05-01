@ECHO OFF
SETLOCAL

SET URL="http://127.0.0.1:1783/api/TodoItems/test"

curl --request GET %URL%

pause