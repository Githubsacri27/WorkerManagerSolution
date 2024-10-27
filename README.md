## Gestión de trabajadores

** LOGIN ADMIN PULSAR 0  ** 

Gestión de trabajadores, modo admin (Versión 1)
Al cargar la aplicación, se mostrará un menú con las siguientes opciones:
1. Register new IT worker
2. Register new team
3. Register new task (unassigned to anyone)
4. List all team names
5. List team members by team name
6. List unassigned tasks
7. List task assignments by team name
8. Assign IT worker to a team as manager
9. Assign IT worker to a team as technician
10.Assign task to IT worker
11.Unregister IT worker
12.Exit

# Diagrama
![image](https://github.com/user-attachments/assets/326870f0-61c1-4f35-8143-0c0b23b1da0d)

# Gestión de trabajadores, modo admin (Versión 1) (requisitos 1 de 2)
- El campo Level de ITWorker solo podrá tener tres valores: Junior, Medium, Senior
- El campo Status de Task solo podrá tener tres valores: To do, Doing, Done
- Definir en la clase Worker un entero estático que se incremente en uno cada vez que se cree un nuevo ITWorker, y usar el valor incrementado como valor del campo Id del nuevo ITWorker creado
- El campo TechKnowledges de ITWorker contiene una lista de strings correspondientes a las
tecnologías que el ITWorker conoce

# Gestión de trabajadores, modo admin (Versión 1) (requisitos 2 de 2) 
- Una tarea solo se puede asignar a un ITWorker si éste conoce la tecnología asociada a dicha tarea, y si la tarea no está en estado Done
- Un ITWorker debe tener nivel Senior para poder ser asignado como Team Manager
- El mínimo nº de años de experiencia para poder ser considerado un ITWorker Senior es 5
- La edad mínima para poder entrar a trabajar como ITWorker es de 18 años

# Gestión de trabajadores, modo multiusuario, con distintos roles (Versión 2)
- Antes de poder acceder a la pantalla de la versión 1, hay que loguearse introduciendo un Id de trabajador (sin contraseña, a lo loco...)
- Si el Id introducido es 0 (Admin), se mostrarán todas las opciones de la versión 1
- Si el Id introducido corresponde con un ITWorker asignado como Manager de un equipo, se mostrarán las opciones 5, 6, 7, 9, 10 y 12, pero la 5 y la 7 solo listarán los miembros de equipo y tareas asignadas correspondientes a su propio equipo
- Si el Id introducido corresponde con un ITWorker no asignado como Manager de ningún equipo, se mostrarán las opciones 6, 7, 10 y 12, pero la 7 solo listará las tareas asignadas a su propio equipo, y la 10 solo le permitirá asignarse tareas a sí mismo
- Mientras lo que sea que se introduzca no corresponde con nada de lo anterior, se volverá a mostrar la pantalla de login

# Falta

- El resto de validaciones de entrada al menu...

# Realizado:
- Crear la estructura de proyectos y clases 
- Crear el proyecto de consola que haga de entrada principal
- Crear el proyecto de libreria de clases
- referenciar en la consola el proyecto de clases
- Referenciar entrada principal del programa consola
- Crear dos carpetas dentro de la librería de clases para organizar
- Crear dentro de Entidades: Worker, ITWorker, Task y Team.
- Crear dentro de metodos: TaskManager, TeamManager, y WorkerManager.
- Crear propiedades de worker y itworker.
- Crear metodos para el registro en WWorkeManager
- Crear metodos para TaskManager
- Añadir validación campo Level, campo Status.
- Añadir contador static de id en  Worker para generar el id de forma auto.
- Validar level senior.
- Añadir las tecnologías en lista.
- Validar la experiencia y la edad
- Añadir login
- Validar Admin
