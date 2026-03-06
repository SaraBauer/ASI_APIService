# API Service

APIService is a Web API listening to https://localhost:7066 and http://localhost:5162 (the latter will redirect to https).

#API Calls
GameController
| Call |  Methods  | Result |
|:-----|:--------:|------:|
| api/game   | HttpPost | creates a new game |
| api/game/{id}   |  HttpPut |  updates an existing game with certain id |
| api/game  | HttpGet |   returns all games from the database|

GuessController
| Call |  Methods  | Result |
|:-----|:--------:|------:|
| api/guess   | HttpPost |  adds a guess to an existing gameresult as a foreign key relation |

#Entity Framework Core
Entity Framework Core was used together with InMemoryDatabase to save results. <br\>
DTOs were used to mitigate the transfer between the API and the Database ensuring decoupling. At this stage, not auto mapping was implemented.
