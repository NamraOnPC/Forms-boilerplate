@ECHO OFF
SETLOCAL

SET URL=http://127.0.0.1:1783/api/TodoItems
SET JSON_HEADER=Content-Type: application/json



CALL :CURL_DELETE "4" 




EXIT /B %ERRORLEVEL%

:CURL_DELETE
		curl --request DELETE "%URL%/%~1"
		EXIT /B 0
		
		