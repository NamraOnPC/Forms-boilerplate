@ECHO OFF
SETLOCAL

SET URL=http://127.0.0.1:1783/api/TodoItems
SET JSON_HEADER=Content-Type: application/json


CALL :CURL_POST "Study C#" "false"
CALL :CURL_POST "Study Java" "false"
CALL :CURL_POST "Study Python" "false"
CALL :CURL_POST "Have a Tea" "false"


EXIT /B %ERRORLEVEL%

:CURL_POST
		curl -v --request POST --header "%JSON_HEADER%" --data "{\"name\":\"%~1\", \"isComplete\":%~2}" "%URL%"
		EXIT /B 0
