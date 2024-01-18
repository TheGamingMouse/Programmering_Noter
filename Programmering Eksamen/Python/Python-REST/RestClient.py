import requests

URL = 'http://localhost:5256/api/Books'

def GetAll():
    response = requests.get(URL)
    data = response.json()
    return data, response

def GetById(id):
    response = requests.get(URL, f'/{id}')
    data = response.json()
    return data, response

def Post(values):
    response = requests.post(URL, json=values)
    data = response.json()
    return data, response

def Put(values, id):
    response = requests.put(f'{URL}/{id}', json=values)
    data = response.json()
    return data, response

def Delete(id):
    response = requests.delete(f'{URL}/{id}')
    data = response.json()
    return data, response