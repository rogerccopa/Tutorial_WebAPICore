# create ticket
$body = @{
            ProjectId = 1
            Title = "This is my first bug"
            Description = "This is my description"
        }
$jsonBody = ConvertTo-Json -inputObject $body
$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets" -Method Post -ContentType "application/json" -Body $jsonBody
$response

# update ticket
$body = @{
            TicketId = 100
            ProjectId = 1
            Title = "This is my first bug updated"
            Description = "This is my description updated"
        }
$jsonBody = ConvertTo-Json -inputObject $body
$response = Invoke-RestMethod -Uri "https://localhost:44390/api/tickets" -Method Put -ContentType "application/json" -Body $jsonBody
$response
