$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets" -Method Get
$response

$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets/123" -Method Get
$response

$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets" -Method Post
$response

$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets" -Method Put
$response

$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets/456" -Method Delete
$response