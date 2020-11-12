import Sequelize from 'sequelize';
import dotenv from 'dotenv';

dotenv.config({ path: '.env' });

// const db = new Sequelize( process.env.DB_NOMBRE, process.env.DB_USER, process.env.DB_PASS, {
//     host: process.env.DB_HOST,
//     port: process.env.DB_PORT,
//     dialect: 'mysql',
//     define: {
//         timestamps: false,        
//     },
//     pool: {
//         max: 5,
//         min: 0,
//         acquire: 30000,
//         idle: 10000
//     },
//     operatorAliases: false
// });

var database = process.env.DATABASE_URL || 'agenciadeviajes'
        var sequelize = ""
 
        if (process.env.DATABASE_URL) {
            sequelize = new Sequelize(database)
        }
        else {
            sequelize = new Sequelize(database, 'mysql', '', {
                dialect: 'mysql'
            });
        }
        
export default db;