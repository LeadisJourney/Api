using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace LeadisTeam.LeadisJourney.Api.Security {
    public class RsaHelper {

        public static void GenerateRsaKeys(string webRootPath) {
            var rsaKey = new RSACryptoServiceProvider(2048);
            var publicKey = rsaKey.ExportParameters(true);
            var rSaParametersWithPrivate = new RSAParametersWithPrivate();
            rSaParametersWithPrivate.SetParameters(publicKey);
            ToJson(rSaParametersWithPrivate, webRootPath);
        }

        private static void ToJson(RSAParametersWithPrivate exportParameters, string webRootPath) {
            using (var file = new FileStream(Path.Combine(webRootPath, "RsaKey.json"), FileMode.Create)) {
                using (var stream = new StreamWriter(file)) {
                    var content = JsonConvert.SerializeObject(exportParameters);
                    stream.Write(content);
                }
            }
        }

        private static RSAParameters FromJson(string path, string fileName) {
            try {
                using (var stream = new StreamReader(new FileStream(Path.Combine(path, fileName), FileMode.Open))) {
                    var content = stream.ReadToEnd();
                    return JsonConvert.DeserializeObject<RSAParametersWithPrivate>(content).ToRSAParameters();
                }
            }
            catch {
                RsaHelper.GenerateRsaKeys(path);
                using (var stream = new StreamReader(new FileStream(Path.Combine(path, fileName), FileMode.Open))) {
                    var content = stream.ReadToEnd();
                    return JsonConvert.DeserializeObject<RSAParametersWithPrivate>(content).ToRSAParameters();
                }
            }
        }

        public static RsaSecurityKey GetRsaSecurityKey(string path, string fileName) {
            return new RsaSecurityKey(FromJson(path, fileName));
        }

        private class RSAParametersWithPrivate {
            public byte[] D { get; set; }
            public byte[] DP { get; set; }
            public byte[] DQ { get; set; }
            public byte[] Exponent { get; set; }
            public byte[] InverseQ { get; set; }
            public byte[] Modulus { get; set; }
            public byte[] P { get; set; }
            public byte[] Q { get; set; }

            public void SetParameters(RSAParameters p) {
                D = p.D;
                DP = p.DP;
                DQ = p.DQ;
                Exponent = p.Exponent;
                InverseQ = p.InverseQ;
                Modulus = p.Modulus;
                P = p.P;
                Q = p.Q;
            }
            public RSAParameters ToRSAParameters() {
                return new RSAParameters() {
                    D = this.D,
                    DP = this.DP,
                    DQ = this.DQ,
                    Exponent = this.Exponent,
                    InverseQ = this.InverseQ,
                    Modulus = this.Modulus,
                    P = this.P,
                    Q = this.Q

                };
            }
        }
    }
}
