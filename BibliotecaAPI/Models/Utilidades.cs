using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BibliotecaAPI.Models
{
    public class Utilidades
    {
        private readonly IConfiguration _configuration;
        public Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // encriptando la clave de usuario
        public string EncriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA3_256 hash = SHA3_256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(clave));

                for (int i = 0; i < result.Length; i++)
                    sb.Append(result[i].ToString("x2"));
            }
            return sb.ToString();
        }
        // generar token al iniciar sesion
        public string genJwt(Usuario usuario)
        {
            // crear informacion del usuario para token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Correo!),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario)
            };

            var seguridadKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credenciales = new SigningCredentials(seguridadKey, SecurityAlgorithms.HmacSha256Signature);

            // crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10), // tiempo que durara el token
                signingCredentials: credenciales
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
