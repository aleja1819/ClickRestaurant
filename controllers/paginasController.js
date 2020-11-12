import { Viaje } from '../models/Viaje.js';
import { Testimonial } from '../models/Testimoniales.js';

// req = lo que yo envío, res = lo que express devuelve
const paginaInicio = async (req, res) => {

    // Consultar 3 viajes del modelo Viaje //
    /* En este caso utilizamos un promise ya que ambas consultan a la base de datos al mismo tiempo y esto con un async await puede
       demorar demasiado si hay muchos datos en la BD, entonces, aqui se realizan ambas consultas al mismo tiempo, ya que como ninguna 
       consulta depende de la otra es recomendable hacerlo así, las guardamos en un arreglo, y luego pormedio del promise se realiza el 
       await para asegurar que las consultas fueron correctas.*/

    const promiseDB = [];

    promiseDB.push(Viaje.findAll({ limit: 3 }));
    promiseDB.push(Testimonial.findAll({ limit:3 }));

    try {
    
        const resultado = await Promise.all( promiseDB )
        res.render('inicio', {
            pagina: 'Inicio',
            clase: 'home',
            viajes: resultado[0],
            testimoniales: resultado[1]
        });                
    } catch (error) {
        console.log(error)
    }

    /**Pruebas del uso de res
 
        // res.send('Hola Mundo');
        // res.json({
        //     id: 1
        // });
        // res.render()

     */
}

const paginaNosotros = (req, res) => {
    res.render('nosotros', {
        pagina: 'Nosotros'
    });
}

const paginaViajes = async (req, res) => {
    // Consultar la bd
    const viajes = await Viaje.findAll();

    // console.log(viajes);

    res.render('viajes', {
        pagina: 'Proximos Viajes',
        viajes
    });
}

const paginaTestimoniales = async (req, res) => {
    try {
        const testimoniales = await Testimonial.findAll();

        res.render('testimoniales', {
            pagina: 'Testimoniales',
            testimoniales
        });        
    } catch (error) {
        console.log(error);
    }

}

// Muestra un viaje por su slug
const paginaDetalleViaje = async (req, res) => {
    // en .params podemos obtener el valor del comodin que se ha declarado en el routing
    
    // Utilizamos try catch para evitar la caida del sistema
    const { slug } = req.params;
    try {
        const viaje = await Viaje.findOne({ where : { slug }});

        res.render('viaje', {
            pagina: 'Información Viaje',
            viaje
        })
    } catch (error) {
        console.log(error)
    }
}

export {
    paginaInicio,
    paginaNosotros,
    paginaViajes,
    paginaDetalleViaje,
    paginaTestimoniales
}