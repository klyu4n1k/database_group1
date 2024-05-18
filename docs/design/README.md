# Проєктування бази даних

## Mодель бізнес-об'єктів

<center style="
    border-radius:4px;
    border: 1px solid #cfd7e6;
    box-shadow: 0 1px 3px 0 rgba(89,105,129,.05), 0 1px 1px 0 rgba(0,0,0,.025);
    padding: 1em;">

@startuml

    entity User
    entity User.id
    entity User.firstname
    entity User.lastname
    entity User.nickname
    entity User.email
    entity User.password
    User.id --* User
    User.firstname --* User
    User.lastname --* User
    User.nickname --* User
    User.email --* User
    User.password --* User

    entity Role
    entity Role.id
    entity Role.name
    Role *-- Role.id
    Role *-- Role.name

    entity Grant
    entity Grant.id
    entity Grant.appointed
    Grant *-- Grant.id
    Grant *-- Grant.appointed

    entity Survey
    entity Survey.id
    entity Survey.title
    entity Survey.description
    entity Survey.createdAt
    Survey *-- Survey.id
    Survey *-- Survey.title
    Survey *-- Survey.description
    Survey *-- Survey.createdAt


    entity Question
    entity Question.id
    entity Question.text
    entity Question.type
    Question *-- Question.id
    Question *-- Question.text
    Question *-- Question.type

    entity Answer
    entity Answer.id
    entity Answer.text
    Answer *-- Answer.id
    Answer *-- Answer.text


    entity Action
    entity Action.id
    entity Action.date
    Action *-- Action.id
    Action *-- Action.date

    entity Permission
    entity Permission.id
    entity Permission.name
    Permission *-- Permission.id
    Permission *-- Permission.name

    entity State
    entity State.id
    entity State.name
    State *-- State.id
    State *-- State.name

    User "0,*"--"1,1" Role
    User "1,1"--"0,*" Answer
    User "1,1"--"0,*" Survey
    Grant "0,*"-u-"1,1" Role
    Survey "1,1"*--"0,*" Question
    Role "1,1"-u-"0,*" Action
    Survey "1,1"--"0,*" Action
    Answer "0,*"--*"1,1" Question
    Grant "0,*"-u-"1,1" Permission
    Action "0,*"--"1,1" State

@enduml

</center>

## ER-модель

<center style="
    border-radius:4px;
    border: 1px solid #cfd7e6;
    box-shadow: 0 1px 3px 0 rgba(89,105,129,.05), 0 1px 1px 0 rgba(0,0,0,.025);
    padding: 1em;">

@startuml

    package UserControl {
    entity User
    {
    id: INT
    first_name: VARCHAR(45)
    last_name: VARCHAR(45)
    nick_name: VARCHAR(45)
    email: VARCHAR(128)
    password: VARCHAR(64)
    }
    }
    package PermissionControl {
    entity Grant    
    {
    id: INT
    appointed: DATE
    }

        entity Role
        {
            id: INT
            name: VARCHAR(32)
        }

        entity Permission
        {
            id: INT
            name: VARCHAR(32)
        }
    }

    package SurveyControl {
    entity Survey
    {
    id: INT
    title: VARCHAR(45)
    description: LONGTEXT
    created: DATE
    }

        entity Answer
        {
            id: INT
            text: LONGTEXT
        }

        entity Question
        {
            id: INT
            text: LONGTEXT
            type: VARCHAR(32)
        }

        entity Action
        {
            id: INT
            date: DATE
        }

        entity State
        {
            id: INT
            name: VARCHAR(32)
        }
    }
    User "0,*"--"1,1" Role
    User "1,1"--"0,*" Answer
    User "1,1"--"0,*" Survey
    Grant "0,*"--"1,1" Role
    Survey "1,1"*--"0,*" Question
    Role "1,1"--"0,*" Action
    Survey "1,1"--"0,*" Action
    Answer "0,*"--*"1,1" Question
    Grant "0,*"--"1,1" Permission
    Action "0,*"--"1,1" State

@enduml

</center>

## Реляційна схема

![relation-diagram](./images/diagram.png)