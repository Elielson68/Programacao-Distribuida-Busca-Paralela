import socket
import time
import datetime



HOST = "localhost"
PORT = 12000



s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect((HOST, PORT))
file = "file=Arquivo_teste.txt"

while True:
    path = input("Digite o PATH: ")
    tempo_inicial = time.time()
    s.sendall(bytes(f"path={path} {file}".encode("utf-8")))
    print(s.recv(102400).decode("utf-8"))
    tempo_final = time.time()
    tempo_exec = tempo_final-tempo_inicial
    print("Tempo:", datetime.timedelta(seconds=tempo_exec))