

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
import bodyParser from 'body-parser';
import path from 'path';
import configs from './config';
import routes from './routes';

require('dotenv').config({ path: '.env' });

// Conectar la base de datos
db.authenticate()
    .then( () => console.log('Base de datos conectada!'))
    .catch( error => console.log(error));

const app = express();

// Habilitar Pug
app.set('view engine', 'pug');

// añadir las vistas
app.set('views', path.join(__dirname, './views'));

// Definir directorio public
app.use(express.static('public'));

const config = configs[app.get('env')];

app.locals.titulo = configs.nombresitio;

// Obtener el año actual
app.use( (req, res, next) => {
    const year = new Date();

    res.locals.actualYear = year.getFullYear();
    // res.locals.nombresitio = "Agencia de Viajes";
    res.locals.ruta = req.path;

    return next();
})

app.use(bodyParser.urlencoded({extended: true}));


app.use('/', routes());


/**Puerto y Host para la app */
// Definir host 
const host = process.env.HOST || '0.0.0.0';
// Definir puerto
const port = process.env.PORT || 4000;


// Agregar bodyParser para leer los datos del formulario
// app.use(express.urlencoded({extended: true}));

// Agregar Router
/*
    use soporta:
    -get
    -post
    -put
    -patch
    -delete
*/




app.listen( port, host,  () => {
    console.log(`El servidor está funcionando en el puerto ${port}`)
});
