CREATE DATABASE GestionPiscinas
USE GestionPiscinas

CREATE TABLE Cliente (
    ClienteID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Email VARCHAR(100),
    Telefono VARCHAR(20)
);

CREATE TABLE Piscina (
    PiscinaID INT PRIMARY KEY,
    Ubicacion VARCHAR(100),
    Tamano VARCHAR(50),
    Capacidad INT
);

CREATE TABLE Reserva (
    ReservaID INT PRIMARY KEY,
    ClienteID INT,
    PiscinaID INT,
    FechaInicio DATE,
    FechaFin DATE,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID),
    FOREIGN KEY (PiscinaID) REFERENCES Piscina(PiscinaID)
);

CREATE TABLE Empleado (
    EmpleadoID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Cargo VARCHAR(50)
);

CREATE TABLE Piscina_Empleado (
    PiscinaID INT,
    EmpleadoID INT,
    PRIMARY KEY (PiscinaID, EmpleadoID),
    FOREIGN KEY (PiscinaID) REFERENCES Piscina(PiscinaID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleado(EmpleadoID)
);

CREATE TABLE Servicio (
    ServicioID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

CREATE TABLE Piscina_Servicio (
    PiscinaID INT,
    ServicioID INT,
    PRIMARY KEY (PiscinaID, ServicioID),
    FOREIGN KEY (PiscinaID) REFERENCES Piscina(PiscinaID),
    FOREIGN KEY (ServicioID) REFERENCES Servicio(ServicioID)
);

CREATE TABLE Repuesto (
    RepuestoID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Precio DECIMAL(10, 2)
);

CREATE TABLE Producto (
    ProductoID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Precio DECIMAL(10, 2)
);

CREATE TABLE Piscina_Repuesto (
    PiscinaID INT,
    RepuestoID INT,
    Cantidad INT,
    PRIMARY KEY (PiscinaID, RepuestoID),
    FOREIGN KEY (PiscinaID) REFERENCES Piscina(PiscinaID),
    FOREIGN KEY (RepuestoID) REFERENCES Repuesto(RepuestoID)
);

CREATE TABLE Piscina_Producto (
    PiscinaID INT,
    ProductoID INT,
    Cantidad INT,
    PRIMARY KEY (PiscinaID, ProductoID),
    FOREIGN KEY (PiscinaID) REFERENCES Piscina(PiscinaID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);
