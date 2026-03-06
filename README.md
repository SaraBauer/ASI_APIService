# API Service

APIService is a Web API listening to https://localhost:7066 and http://localhost:5162 (the latter will redirect to https).

#API Calls
GameController
| Call |  Methods  | Result |
|:-----|:--------:|------:|
| api/game   | HttpPost | creates a new game |
| api/game/{id}   |  HttpPut |  updates an existing game with certain id |
| api/game  | HttpGet |   returns all games from the database|
