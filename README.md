# Unicauca Conectada

Unicauca Conectada es un proyecto cuyo fin es implementar una aplicación de
escritorio para acceder a todos los eventos en la Universidad. La aplicación
utiliza un enfoque que permite a los usuarios publicar, etiquetar y encontrar
eventos fácilmente, así como seguir a los organizadores de eventos. La
aplicación también proporciona a los organizadores una forma de contactar a los
estudiantes por medio de notificaciones. Se planea seguir un modelo basado en
calificaciones para ayudar a los estudiantes a escoger con mayor fiabilidad qué
eventos pagos le parezcan más relevantes. \
MongoDB Atlas, C#, .NET

# Arquitectura

Se decidió aplicar un diseño arquitectónico por capas por ventajas como:
* Fácil de entender para equipos nuevos en el desarrollo de software.
* Versatilidad a la hora de desarrollar software con cortos plazos de entrega.
* Flexibilidad para realizar mantenimiento.
Adicionalmente, los miembros del equipo tiene algo de experiencia con esta
arquitectura y otras afines tales con MVC.

# Vista de componentes y conectores

![Componentes y conectores](images/model/c&c.png)

# Vista de módulos (UML)

![MVT](images/model/mvt.png)

# Vista de instalación (UML)

![Instalacion](images/model/instalacion.png)

# Base de datos

El motor de base de datos a utilizar es MondoDB

![Digrama de base de datos](images/database/basededatos.png) 

# C4

Se hace uso de modelos C4 para representar la arquitectura de la aplicación en
diferentes niveles de abstracción: 

1. Diagrama de contexto
2. Diagrama de contenedores
3. Diagrama de componentes
    * Interfaz de usuario
    * Backend 

## Diagrama de contexto

![Diagrama de contexto](images/c4/contexto.png)

## Diagrama de contenedores

![Diagrama de contenedores](images/c4/contenedores.png)

## Diagrama de componentes

### Interfaz de usuario

![Diagrama de componentes GUI](images/c4/componentesGUI.png)

### Backend

![Diagrama de componentes Backend](images/c4/componentesBackend.png)

# Equipo de desarrollo

El equipo de desarrollo de Unicauca Conetada esta integrado por:  
- [David Jiménez](https://github.com/dohimenezg)
- [Julian Ordoñez](https://github.com/juleMay)
- [Daniel Pastas](https://github.com/pdaniel102)

