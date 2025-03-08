

Este proyecto en C# implementa un **sistema de registro de equipos y jugadores** para un torneo de fútbol. Se utilizan:

- **Diccionario (Dictionary<string, HashSet<Jugador>>)** para mapear cada equipo a un conjunto de jugadores.  
- **Clase Jugador** con nombre, edad, posición y número de camiseta (evita duplicados sobrescribiendo Equals y GetHashCode).  
- **Menú de consola** para registrar equipos, agregar jugadores y consultar la información.  
- **Función de limpieza de pantalla** que llama a Console.Clear().

## Requisitos
- **.NET 6.0** o superior  
- Editor/IDE con soporte C#

## Uso
1. Clona/descarga el repositorio.  
2. Compila:  
   ```bash
   csc Program.cs
   ```  
3. Ejecuta el .exe resultante.  
4. Sigue las opciones del menú para:
   - Registrar equipos (1)  
   - Agregar jugadores (2)  
   - Visualizar equipos (3)  
   - Consultar jugadores de un equipo (4)  
   - Salir (5)

## Personalización
- Ajusta la lógica de `Equals` y `GetHashCode` para cambiar el criterio de duplicado.  
- Reemplaza el diccionario por una base de datos para persistencia, si se requiere.

## Licencia
[MIT](https://opensource.org/licenses/MIT) - siéntete libre de modificar y distribuir.
