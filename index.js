

// Creamos el servidor de express, es como apache para php
/*Sintaxis CommonJS - no es propia de JS
const express = require('express');

Pero actualmente se soporta import y se escribe de la siguiente forma

    import express from 'express';

Y agregamos en el package.json lo siguiente:
    
    "type": "module",
*/
import express from 'express';
import router from './routes/index.js';
import db from './config/db.js';

const app = express();

// Conectar la base de datos
db.authenticate()
    .then( () => console.log('Base de datos conectada!'))
    .catch( error => console.log(error));

/**Puerto y Host para la app */

// Definir host 
const host = process.env.HOST || '0.0.0.0';
// Definir puerto
const port = process.env.PORT || 4000;

// Habilitar Pug
app.set('view engine', 'pug');

// Obtener el año actual
app.use( (req, res, next) => {
    const year = new Date();

    res.locals.actualYear = year.getFullYear();
    res.locals.nombresitio = "Agencia de Viajes";

    return next();
})

// Agregar bodyParser para leer los datos del formulario
app.use(express.urlencoded({extended: true}));

// Definir directorio public
app.use(express.static('public'));

// Agregar Router
/*
    use soporta:
    -get
    -post
    -put
    -patch
    -delete
*/
app.use('/', router);



app.listen( port, host,  () => {
    console.log(`El servidor está funcionando en el puerto ${port}`)
});
