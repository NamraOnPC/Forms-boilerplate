@ECHO OFF
SETLOCAL

SET URL="http://127.0.0.1:1783/api/TodoItems"
SET JSON_HEADER="Content-Type: application/json"

curl --request GET %URL%

pause