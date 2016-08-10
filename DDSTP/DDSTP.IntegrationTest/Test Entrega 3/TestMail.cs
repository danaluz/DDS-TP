using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Proxies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class TestMail
    {
        [TestMethod]
        public void Test_Send_Email()
        {
            var emailProxy = new EmailProxy();
            var c1 = "Estimado:";
            var c2 =
                "Actualmente todas las ambigüedades presentes en el TP son catalogadas como decisiones de diseño y quedan a cargo del alumno. O en su defecto de preguntar solamente las dudas, en un recreo, o no se bien cuándo ya que no se cuentan con espacios de consultas a ese efecto.";
            var c3 =
                "El principal problema, es que cada uno tiene su interpretación de las consignas, que entra en conflicto con lo que los docentes esperan. Entonces, la entrega está mal y hay que rehacerla.";
            var c4 =
                "No estoy de acuerdo con cómo se está manejando el tema. El TP no debería tener ambigüedades. Nunca nos llegó ninguna encuesta de las entregas anteriores. No tengo ni idea del sistema de tutoría que se menciona.Los docentes llegan tarde a la clase. Esto lo quiero mencionar porque encima de no tener los espacios de consulta, se hace más dificil cuando están apurados porque están una hora atrasados en clase. ";
            var c5 = "Todas las clases son diapositivas, no tuvimos ni una con un docente codificando.";
            var c6 = "No se está evaluando la prolijidad del código, ni el uso de buenas prácticas, ni librerías externas. No nos piden diagramas de clase en las entregas. Disiento al respecto del lenguaje: en una misma entrega hay que 1) conectarse a una servicio externo (que ya tiene ambiguedades, como el caso de los locales comerciales) pero que no existe, así que hay saber mockear los datos para probarlos 2) usar un servicio para mandar mail,  3) realizar los test de todo lo anterior 4) implementar un patron de diseño (que en nuestro curso fue impuesto, ya que nos mandaron un mail con el patron a utilizar, sin haberlo visto en clase y sin demasiada explicación de porqué).";
            var c7 = "En ninguna materia anterior se tuvo la oportunidad, si quiera, de armar una página web en HTML plano, y de repente, sin ningun apoyo, hacer todo lo anterior mencionado. No tiene sentido. Sientase libre de responder al mail alter@outlook. Saludos";

            var content= c1+Environment.NewLine+c2+Environment.NewLine+c3+Environment.NewLine+c4+Environment.NewLine+c5+Environment.NewLine+c6+
            Environment.NewLine+c7;

            emailProxy.SendToAdmin("Diseño de Sistemas", content);

        }
    }
}
