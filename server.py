#!/usr/bin/python3
import socket, ssl, http.server

# https://www.digitalocean.com/community/tutorials/openssl-essentials-working-with-ssl-certificates-private-keys-and-csrs
# sudo openssl req -newkey rsa:2048 -nodes -keyout domain.key -x509 -days 365 -out domain.crt

class Handler(http.server.SimpleHTTPRequestHandler):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, directory = "web", **kwargs)

    def end_headers(self):
        self.send_header("Access-Control-Allow-Origin", "*")
        http.server.SimpleHTTPRequestHandler.end_headers(self)

ctx = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
ctx.load_cert_chain("domain.crt", "domain.key")
ctx.check_hostname = False
httpd = http.server.HTTPServer(("0.0.0.0", 443), Handler)
httpd.socket = ctx.wrap_socket(httpd.socket, server_hostname = "localhost")
print("Now serving at https://localhost")
httpd.serve_forever()

