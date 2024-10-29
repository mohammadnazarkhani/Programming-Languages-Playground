import peewee

# Define the database
db = peewee.SqliteDatabase('my_database.db')

# Define a model
class User(peewee.Model):
    username = peewee.CharField(unique=True)
    email = peewee.CharField()
    created_at = peewee.DateTimeField(constraints=[peewee.SQL('DEFAULT CURRENT_TIMESTAMP')])

    class Meta:
        database = db  # This model uses the "my_database.db" database.

# Connect to the database and create tables
def initialize():
    db.connect()
    db.create_tables([User], safe=True)

def create_user(username, email):
    if User.select().where(User.username == username).exists():
        print(f'User {username} already exists!')
    else:
        user = User(username=username, email=email)
        user.save()
        print(f'User {username} created!')

def list_users():
    for user in User.select():
        print(f'User: {user.username}, Email: {user.email}')

if __name__ == '__main__':
    initialize()
    create_user('john_doe', 'john@example.com')
    create_user('john_doe', 'john.doe@example.com')  # This will trigger the unique constraint
    list_users()
