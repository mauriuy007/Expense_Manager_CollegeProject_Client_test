# 🖥️ Cliente MVC — Interfaz para API del Sistema de Gestión de Gastos

Este repositorio contiene el **cliente MVC utilizado para consumir las APIs** del proyecto *Sistema de Gestión de Gastos* (Obligatorio Programación 3).

➡️ **Importante:** Este cliente **no sigue Clean Architecture**, ni una estructura organizada.  
Se desarrolló únicamente con el objetivo de **aprender**:

- Cómo consumir APIs desde controladores MVC  
- Cómo estructurar requests desde el cliente  
- Cómo manejar DTOs para enviar datos al servidor  
- Cómo funciona la interacción Cliente ⇄ Servidor en ASP.NET MVC  

---

## 🧠 ¿Qué hace este cliente?

El cliente permite:

- Enviar datos a la API del backend  
- Mostrar información devuelta por la API  
- Crear usuarios, pagos, gastos, equipos (dependiendo de lo implementado)  
- Validar que los endpoints del servidor funcionen correctamente  
- Interactuar con la API sin Postman, usando únicamente vistas MVC  

No implementa:
- Clean Architecture  
- Validaciones completas  
- Manejo de errores avanzado  
- Seguridad (más allá de enviar JWT si corresponde)  

Es un cliente **simple, instrumental y académico**.

---

# 🏗️ Estructura del Proyecto (Cliente)

```
📦 N3C_348209_Client/
│
├── 📁 Controllers/          # Controladores MVC que consumen la API
│   ├── UserController.cs
│   ├── ExpenseController.cs
│   ├── PaymentController.cs
│   └── TeamController.cs
│
├── 📁 Views/                # Vistas asociadas a cada controlador
│   ├── User/
│   ├── Expense/
│   ├── Payment/
│   └── Team/
│
├── 📁 Models/               # DTOs usados para enviar/recibir datos
│
├── Program.cs               # Configuración básica
└── appsettings.json         # URL del backend + settings del cliente
```

---

# 🔌 Comunicación con el Backend

Este cliente envía requests al backend mediante:

- `HttpClient`
- DTOs locales que coinciden con los del backend
- JSON enviado vía POST / PUT
- Endpoints definidos en el proyecto del servidor

Ejemplo general de pegada:

```csharp
var json = JsonConvert.SerializeObject(dto);
var content = new StringContent(json, Encoding.UTF8, "application/json");

var response = await _httpClient.PostAsync("https://tuservidor/api/expenses", content);
```

---

# 🌐 Requisitos

- Tener corriendo **el servidor backend** (API).  
- Configurar la URL de la API en `appsettings.json`:

```json
{
  "ApiUrl": "https://localhost:7010/api"
}
```

- Ejecutar el proyecto en Visual Studio o VS Code.

---

# 🚀 Cómo Ejecutarlo

1. Clonar el repositorio:

```bash
git clone https://github.com/tuusuario/N3C_348209_Client.git
```

2. Configurar la URL del backend en `appsettings.json`.

3. Ejecutar el proyecto:

```
F5 en Visual Studio      — o —
dotnet run
```

4. Navegar por las vistas y probar las interacciones con la API.

---

# 📌 Aclaración sobre la calidad del código

Este cliente **no está diseñado como un proyecto final profesional**.  
Se creó exclusivamente para:

- aprender la comunicación MVC → API  
- validar los casos de uso del backend  
- practicar consumo de endpoints  
- avanzar en Programación 3  

No representa un frontend real ni una arquitectura limpia.

---

# 🧑‍💻 Autor

Desarrollado por **Mauricio Parodi** 🇺🇾  
Cliente MVC del obligatorio de **Programación 3 – Universidad ORT**.

