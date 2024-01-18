from RestClient import *

userInput = input('Vælg en modetode ("Print", "PrintId", "Opdater", "Ny", "Slet": ')
sentence = userInput.lower()

if sentence == 'print':
    print('Alle bøger')
    books, resp = GetAll()
    print(resp.status_code)
    for book in books:
        print(book)

elif sentence == 'printid':
    bookId = int(input('Indtast Id: '))

    print(f'Bog nummer {bookId}')
    books, resp = GetById(bookId)
    print(resp.status_code)
    for book in books:
        if book['id'] == bookId:
            print(book)

elif 'opdater' in sentence:
    bookId = int(input('Intast Id: '))
    newName = input('Indtast nyt navn: ')
    newPrice = int(input('Indtast ny pris: '))
    values = {
        "title": newName,
        "price": newPrice
    }

    print(f'Bog nummer {bookId} opdateret')
    books, resp = Put(values, bookId)
    print(resp.status_code)
    print(resp.content)

elif 'ny' in sentence:
    name = input('Indtast navn: ')
    price = int(input('Indtast pris: '))
    values = {
        "title": name,
        "price": price
    }
    
    print(f'Bog "{name}" lavet')
    books, resp = Post(values)
    print(resp.status_code)
    print(resp.content)

elif 'slet' in sentence:
    bookId = int(input('Indtast id: '))

    userResp = input(f'Er du sikker på at du vil slette bog nummer {bookId}? (skriv "ja", eller "nej": ')
    userResp = userResp.lower()

    if userResp == 'ja':
        books, resp = Delete(bookId)
        print(f'Bog nummer {bookId} er slettet')
        print(resp.status_code)
        print(resp.content)
    else:
        print(f'Slettelse af bog nummer {bookId} er fotrudt')

else:
    print('Forkert input')
