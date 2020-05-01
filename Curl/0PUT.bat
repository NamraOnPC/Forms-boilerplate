@ECHO OFF
SETLOCAL

SET URL=http://127.0.0.1:1783/api/TodoItems
SET JSON_HEADER=Content-Type: application/json



CALL :CURL_PUT "1" "Study C#" "true"


EXIT /B %ERRORLEVEL%

:CURL_PUT
		curl -v --request PUT --header "%JSON_HEADER%" --data "{\"id\":%~1, \"name\":\"%~2\", \"isComplete\":%~3}" "%URL%/%~1"
		EXIT /B 0
		
		