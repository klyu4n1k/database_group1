# Реалізація інформаційного та програмного забезпечення

## SQL-скрипт для створення на початкового наповнення бази даних

    -- MySQL Workbench Forward Engineering
    
    SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
    SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
    SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
    
    -- -----------------------------------------------------
    -- Schema quiz
    -- -----------------------------------------------------
    DROP SCHEMA IF EXISTS `quiz` ;
    
    -- -----------------------------------------------------
    -- Schema quiz
    -- -----------------------------------------------------
    CREATE SCHEMA IF NOT EXISTS `quiz` DEFAULT CHARACTER SET utf8 ;
    USE `quiz` ;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Role`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Role` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Role` (
    `id` INT NOT NULL,
    `name` VARCHAR(32) NULL,
    PRIMARY KEY (`id`))
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Permission`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Permission` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Permission` (
    `id` INT NOT NULL,
    `name` VARCHAR(32) NULL,
    PRIMARY KEY (`id`))
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Grant`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Grant` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Grant` (
    `id` INT NOT NULL,
    `appointed` DATE NULL,
    `Role_id` INT NOT NULL,
    `Permission_id` INT NOT NULL,
    PRIMARY KEY (`id`, `Role_id`, `Permission_id`),
    INDEX `fk_Grant_Role1_idx` (`Role_id` ASC) VISIBLE,
    INDEX `fk_Grant_Permission1_idx` (`Permission_id` ASC) VISIBLE,
    CONSTRAINT `fk_Grant_Role1`
    FOREIGN KEY (`Role_id`)
    REFERENCES `quiz`.`Role` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    CONSTRAINT `fk_Grant_Permission1`
    FOREIGN KEY (`Permission_id`)
    REFERENCES `quiz`.`Permission` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`User`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`User` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`User` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `first_name` VARCHAR(45) NULL,
    `last_name` VARCHAR(45) NULL,
    `nick_name` VARCHAR(45) NULL,
    `email` VARCHAR(128) NULL,
    `password` VARCHAR(64) NULL,
    `Role_id` INT NOT NULL,
    PRIMARY KEY (`id`, `Role_id`),
    INDEX `fk_User_Role1_idx` (`Role_id` ASC) VISIBLE,
    UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
    UNIQUE INDEX `nick_name_UNIQUE` (`nick_name` ASC) VISIBLE,
    CONSTRAINT `fk_User_Role1`
    FOREIGN KEY (`Role_id`)
    REFERENCES `quiz`.`Role` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Survey`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Survey` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Survey` (
    `id` INT NOT NULL,
    `title` VARCHAR(45) NULL,
    `description` LONGTEXT NULL,
    `created` DATE NULL,
    `User_id` INT NOT NULL,
    `User_Role_id` INT NOT NULL,
    PRIMARY KEY (`id`, `User_id`, `User_Role_id`),
    INDEX `fk_Survey_User1_idx` (`User_id` ASC, `User_Role_id` ASC) VISIBLE,
    CONSTRAINT `fk_Survey_User1`
    FOREIGN KEY (`User_id` , `User_Role_id`)
    REFERENCES `quiz`.`User` (`id` , `Role_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Question`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Question` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Question` (
    `id` INT NOT NULL,
    `text` LONGTEXT NULL,
    `type` VARCHAR(32) NULL,
    `Survey_id` INT NOT NULL,
    `Survey_User_id` INT NOT NULL,
    `Survey_User_Role_id` INT NOT NULL,
    PRIMARY KEY (`id`, `Survey_id`, `Survey_User_id`, `Survey_User_Role_id`),
    INDEX `fk_Question_Survey1_idx` (`Survey_id` ASC, `Survey_User_id` ASC, `Survey_User_Role_id` ASC) VISIBLE,
    CONSTRAINT `fk_Question_Survey1`
    FOREIGN KEY (`Survey_id` , `Survey_User_id` , `Survey_User_Role_id`)
    REFERENCES `quiz`.`Survey` (`id` , `User_id` , `User_Role_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Answer`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Answer` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Answer` (
    `id` INT NOT NULL,
    `text` LONGTEXT NULL,
    `User_id` INT NOT NULL,
    `User_Role_id` INT NOT NULL,
    `Question_id` INT NOT NULL,
    `Question_Survey_id` INT NOT NULL,
    `Question_Survey_User_id` INT NOT NULL,
    `Question_Survey_User_Role_id` INT NOT NULL,
    PRIMARY KEY (`id`, `User_id`, `User_Role_id`, `Question_id`, `Question_Survey_id`, `Question_Survey_User_id`, `Question_Survey_User_Role_id`),
    INDEX `fk_Answer_User1_idx` (`User_id` ASC, `User_Role_id` ASC) VISIBLE,
    INDEX `fk_Answer_Question1_idx` (`Question_id` ASC, `Question_Survey_id` ASC, `Question_Survey_User_id` ASC, `Question_Survey_User_Role_id` ASC) VISIBLE,
    CONSTRAINT `fk_Answer_User1`
    FOREIGN KEY (`User_id` , `User_Role_id`)
    REFERENCES `quiz`.`User` (`id` , `Role_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    CONSTRAINT `fk_Answer_Question1`
    FOREIGN KEY (`Question_id` , `Question_Survey_id` , `Question_Survey_User_id` , `Question_Survey_User_Role_id`)
    REFERENCES `quiz`.`Question` (`id` , `Survey_id` , `Survey_User_id` , `Survey_User_Role_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`State`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`State` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`State` (
    `id` INT NOT NULL,
    `name` VARCHAR(32) NULL,
    PRIMARY KEY (`id`))
    ENGINE = InnoDB;
    
    -- -----------------------------------------------------
    -- Table `quiz`.`Action`
    -- -----------------------------------------------------
    DROP TABLE IF EXISTS `quiz`.`Action` ;
    
    CREATE TABLE IF NOT EXISTS `quiz`.`Action` (
    `id` INT NOT NULL,
    `date` DATE NULL,
    `Survey_id` INT NOT NULL,
    `Survey_User_id` INT NOT NULL,
    `Survey_User_Role_id` INT NOT NULL,
    `Role_id` INT NOT NULL,
    `State_id` INT NOT NULL,
    PRIMARY KEY (`id`, `Survey_id`, `Survey_User_id`, `Survey_User_Role_id`, `Role_id`, `State_id`),
    INDEX `fk_Action_Survey1_idx` (`Survey_id` ASC, `Survey_User_id` ASC, `Survey_User_Role_id` ASC) VISIBLE,
    INDEX `fk_Action_Role1_idx` (`Role_id` ASC) VISIBLE,
    INDEX `fk_Action_State1_idx` (`State_id` ASC) VISIBLE,
    CONSTRAINT `fk_Action_Survey1`
    FOREIGN KEY (`Survey_id` , `Survey_User_id` , `Survey_User_Role_id`)
    REFERENCES `quiz`.`Survey` (`id` , `User_id` , `User_Role_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    CONSTRAINT `fk_Action_Role1`
    FOREIGN KEY (`Role_id`)
    REFERENCES `quiz`.`Role` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    CONSTRAINT `fk_Action_State1`
    FOREIGN KEY (`State_id`)
    REFERENCES `quiz`.`State` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
    ENGINE = InnoDB;
    
    
    SET SQL_MODE=@OLD_SQL_MODE;
    SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
    SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

## RESTfull сервіс для управління даними

RESTful сервіс для керування таблицею User у базі даних 'quiz', створеної на MySQL, реалізовано за допомогою фреймворку Flask на Python.
Цей сервіс є базовим CRUD застосунком, що забезпечує функції створення (Create), читання (Read), оновлення (Update) та видалення (Delete) даних.

### Файл test.py 

    from flask import Flask, request, jsonify
    from flask_restful import Resource, Api
    from flask_sqlalchemy import SQLAlchemy
    
    app = Flask(__name__)
    api = Api(app)

    app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql+mysqlconnector://root:2005@localhost/quiz'
    app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
    db = SQLAlchemy(app)

    class RoleModel(db.Model):
        __tablename__ = 'Role'
        id = db.Column(db.Integer, primary_key=True)
        name = db.Column(db.String(45))
        users = db.relationship('UserModel', backref='role')

    class UserModel(db.Model):
        __tablename__ = 'User'
        id = db.Column(db.Integer, primary_key=True, autoincrement=True)
        first_name = db.Column(db.String(45))
        last_name = db.Column(db.String(45))
        nick_name = db.Column(db.String(45), unique=True)
        email = db.Column(db.String(128), unique=True)
        password = db.Column(db.String(64))
        role_id = db.Column(db.Integer, db.ForeignKey('Role.id'), nullable=False)

        def to_dict(self):
            return {
                "id": self.id,
                "first_name": self.first_name,
                "last_name": self.last_name,
                "nick_name": self.nick_name,
                "email": self.email,
                "password": self.password,
                "role_id": self.role_id
            }


    with app.app_context():
        db.create_all()
    
    class User(Resource):
        def get(self, user_id=None):
            if user_id is None:
                users = UserModel.query.all()
                return [user.to_dict() for user in users]
            else:
                user = UserModel.query.get(user_id)
            if user:
                return user.to_dict()
            return {'message': 'User not found'}, 404

        def post(self):
            data = request.get_json()
            existing_user_email = UserModel.query.filter_by(email=data.get('email')).first()
            existing_user_nick = UserModel.query.filter_by(nick_name=data.get('nick_name')).first()
            if existing_user_email is not None:
                return {'message': 'User with this email already exists'}, 400
            if existing_user_nick is not None:
                return {'message': 'User with this nickname already exists'}, 400
            new_user = UserModel(
                first_name=data.get('first_name'),
                last_name=data.get('last_name'),
                nick_name=data.get('nick_name'),
                email=data.get('email'),
                password=data.get('password'),
                role_id=data.get('role_id')
            )
            db.session.add(new_user)
            db.session.commit()
            return {'message': 'User created successfully', 'user': new_user.to_dict()}, 201

        def put(self, user_id):
            user = UserModel.query.get(user_id)
            if user:
                data = request.get_json()
                user.first_name = data.get('first_name', user.first_name)
                user.last_name = data.get('last_name', user.last_name)
                user.nick_name = data.get('nick_name', user.nick_name)
                user.email = data.get('email', user.email)
                user.password = data.get('password', user.password)
                user.role_id = data.get('role_id', user.role_id)
                db.session.commit()
                return {'message': 'User updated successfully', 'user': user.to_dict()}
            return {'message': 'User not found'}, 404

        def delete(self, user_id):
            user = UserModel.query.get(user_id)
            if user:
                db.session.delete(user)
                db.session.commit()
                return {'message': 'User deleted successfully'}, 200
            return {'message': 'User not found'}, 404

    api.add_resource(User, '/users', '/users/<int:user_id>')
    
    @app.route('/')
    def index():
    return "Welcome to the User API"
    
    if __name__ == '__main__':
    app.run(debug=True)