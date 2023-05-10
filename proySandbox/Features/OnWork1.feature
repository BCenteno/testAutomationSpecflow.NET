Feature: OnWork 1

Scenario: Brenda practica buscar un valor relacionado
When I load the following data
| Amo  | mascota | nombre    |
| jose | perro   | roco      |
| luis | gato    | ron       |
| ana  | gato    | missyfuzz |
Then "ron" es un "gato"

Scenario: Brenda practica valor indirecto
When I load TA
| Amo  | mascota | nombre    |
| jose | perro   | roco      |
| luis | gato    | ron       |
| ana  | gato    | missyfuzz |
When I load TB
| comida   | mascota |
| basura   | perro   |
| galletas | gato |
| semillas | perico  |
Then "ana" compra "galletas"

#NEW ACTIVITY

Scenario: Brenda construye un json desde tablas
When I load TA
| Amo  | telefono |
| pepe | 0123     |
| pepe | 0500     |
| jose | 132      |
| ana  | 325      |
| ana  | 334      |
Then the json is created


