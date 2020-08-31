# PokemonShakespeareTranslatorAPI

The aim of this application is to translate the description of a pokemon in a shakespearean language.
You can use it for free but you have only 5 calls for hours and 60 calls a day. If you want more you have to pay(Please visit https://funtranslations.com/api/shakespeare).

## How to run 

#### Directly from the solution

- There are two files PokemonTranslatorx64.rar and PokemonTranslatorx86.rar respectively for x86 and x64 architecture.
- Unzip the file releated to your architecture and then run the file PokemonShakespeareTranslatorAPI.exe.
- Wait for the starting of the service.
- When the service starts you can see the http and https address.
- Then open a web browser and call the service : {http or https address}/pokemon/{name of the pokemon} for example : https://localhost:5001/pokemon/charizard


#### Via Docker

- First of all install docker desktop on your pc(https://www.docker.com/get-started)
- Go in the root folder of the project and run the command : docker build -f Dockerfile . -t pokemontranslator
- When the build of the container is done you can lunch the container with the command : docker run -it --rm -p "5500:80" pokemontranslator
- When the container starts you can calle the service via url http://localhost:5500/Pokemon/charizard
