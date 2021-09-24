# SAT Recruitment Challenge

La forma que decidí resolver este challegue fue agregando 3 capas(Domain, Services, DataAccess) que se compartan de la siguiente manera:
dentro de mi capa de Domain tengo los DTOs, Entities y Enums. 
Dentro de mi capa se Servicio tengo los métodos y funciones que se encargaran de validar la generación de usuario si este ya existe o no, los porcentajes a aplicar por tipo de usuario.
Dentro de mi capa DataAccess decidí hacer un método que me retorne todos los usuarios que están en el archivo .txt para después en mi capa de servicio validar los mismos.
Toda la lógica la hice en mi capa de Servicio. Esta arquitectura fue realizada siguiendo los principios de Clean Architecture.
