// See https://aka.ms/new-console-template for more information

// EXAMEN 1 DESARROLLO DE GESTIÓN DE PACIENTES Y CONSULTAS MÉDICAS
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

// Limpia el terminal para mostrar el menú
Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("+------------[GESTIÓN DE PACIENTES Y CONSULTAS MÉDICAS]------------+               #########");
Console.WriteLine("+                                                                  +               #+++++++#");
Console.WriteLine("+                                                                  +               #+++++++#");
Console.WriteLine("+         (1) - Agregar Paciente                                   +         #######+++++++#######");
Console.WriteLine("+         (2) - Agregar Medicamento al Catálogo                    +         #+++++++++++++++++++#");
Console.WriteLine("+         (3) - Asignar tratamiento médico a un paciente           +         #+++++++++++++++++++#");
Console.WriteLine("+         (4) - Consultas                                          +         #######+++++++#######");
Console.WriteLine("+         (5) - Salir del Programa                                 +               #+++++++#");
Console.WriteLine("+                                                                  +               #+++++++#");
Console.WriteLine("+------------------------------------------------------------------+               #########");

// Declara las variables del menú principal y los arreglos del programa
int menu = 0, opcion = 0, contador = 0;
int[] telefono = new int[255];
string[] nombre = new string[255], BloodType = new string[255];
string[] direccion = new string[255], birthday = new string[255];
string[] cedula = new string[255];
bool ERROR = false;
// Arreglos de los medicamentos
string[] MedCode = new string[255], MedName = new string[255];
int[] MedCant = new int[255];
// Arreglos de la asignación de los tratamientos
string[] MedTrata1 = new string[255], Medtrata2 = new string[255];
string[] MedTrata3 = new string[255];
int[] MedtrataCant1 = new int[255], MedtrataCant2 = new int[255];
int[] MedtrataCant3 = new int[255];

do
{
    //  Le solicita al usuario que seleccione una de las opciones que se presentan en el menú
    try
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el número correspondiente a la opción que desea seleccionar: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        menu = int.Parse(Console.ReadLine());

        if (menu > 0 && menu < 6)
        {
            switch (menu)
            {
                case 1:
                    AgregarPaciente();
                    break;
                case 2:
                    AgregarMed();
                    break;
                case 3:
                    AsignarTratamientoMed();
                    break;
                case 4:
                    Consultas();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[SE HA CERRADO EL PROGRAMA]");
                    Environment.Exit(0);
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Se ingresó un número fuera de los parámetros del menú.\nInténtelo de nuevo");
        }
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ingresó un tipo de dato no válido.\nInténtelo de nuevo.");
    }
} while (menu != 5);

void InicializarVectores()
{
    
}

//Declara las funciones
void AgregarPaciente()
{
    //  Le solicita al usuario los datos necesarios para agregar a un paciente
    int submenu01 = 0;
    // SOLICITA EL NOMBRE
    do
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Ingrese el nombre del paciente que desea añadir");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string name = "";
            name = Console.ReadLine();
            bool ErrorMostrado = false;
            bool nombre_real = Regex.IsMatch(name, @"^[a-zA-Z]+$");
            if (nombre_real)
            {
                for (int i = 0; i < nombre.Length; i++)
                {
                    if (nombre[i] == null)
                    {
                        nombre[i] = name;
                        submenu01 = 1;
                        i = nombre.Length;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ese no es un nombre válido.\nEvite ingresar números o símbolos.");

            }
        }
        catch
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Se ha producido un error");
        }

    } while (submenu01 == 0);
    // SOLICITA EL NÚMERO DE TELÉFONO
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el número de teléfono del paciente");
        int numtel = 0;
        try
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            numtel = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ese no es un número de teléfono.");
            submenu01 = 7;
        }
        for (int i = 0; i < telefono.Length; i++)
        {
            if (telefono[i] == 0)
            {
                telefono[i] = numtel;
                submenu01 = 2;
                i = telefono.Length;
            }
        }
    } while (submenu01 == 1);
    // SOLICITA EL TIPO DE SANGRE
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el tipo de sangre del paciente.\nTIPOS DE SANGRE:\nA+    B+    O+\nAB+    AB-    O-\nA-    B-\n........................................");
        string SuSangre = "";
        try
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            SuSangre = Console.ReadLine();
            switch (SuSangre)
            {
                case "A+":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "B+":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "O+":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "AB+":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "AB-":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "O-":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "A-":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                case "B-":
                    for (int i = 0; i < BloodType.Length; i++)
                    {
                        if (BloodType[i] == null)
                        {
                            BloodType[i] = SuSangre;
                            submenu01 = 3;
                            i = BloodType.Length;
                        }
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ese no es un tipo de sangre.\nInténtelo de nuevo.");
                    submenu01 = 7;
                    break;
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Se ha producido un error.");
            submenu01 = 7;
        }
    } while (submenu01 == 2);
    // SOLICITA LA DIRECCIÓN
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese la dirección del paciente.");
        string theAdress = "";

        Console.ForegroundColor = ConsoleColor.Yellow;
        theAdress = Console.ReadLine();

        for (int i = 0; i < direccion.Length; i++)
        {
            if (direccion[i] == null && theAdress.Length > 1)
            {
                direccion[i] = theAdress;
                submenu01 = 4;
                i = direccion.Length;
            }
        }
    } while (submenu01 == 3);
    // SOLICITA LA FECHA DE NACIMIENTO
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese la fecha de nacimiento del paciente.");
        string SuFecha = "";

        Console.ForegroundColor = ConsoleColor.Yellow;
        SuFecha = Console.ReadLine();

        for (int i = 0;i < birthday.Length; i++)
        {
            if (birthday[i] == null && SuFecha.Length > 0)
            {
                birthday[i] = SuFecha;
                submenu01 = 5;
                i = birthday.Length;
            }
        }
    } while (submenu01 == 4);
    // SOLICITA LA CÉDULA
    do
    {
        Console.ForegroundColor= ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el número de cédula del paciente.");
        string SuID = "";
        Console.ForegroundColor = ConsoleColor.Yellow;
        SuID = Console.ReadLine();
        bool SuIDreal = Regex.IsMatch(SuID, @"^\d+$");
        if (SuIDreal && SuID.Length > 0)
        {
            if (SuID.Length < 10)
            {
                for (int i = 0; i < cedula.Length; i++)
                {
                    if (cedula[i] == null)
                    {
                        cedula[i] = SuID;
                        submenu01 = 6;
                        i = cedula.Length;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ese no es una cédula válida.\nDebe tener 9 digitos.");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Esa no es una cédula válida.");
        }

    } while (submenu01 == 5);
}

void AgregarMed()
{
    int submenu02 = 0;
    // SOLICITA EL CÓDIGO DEL MEDICAMENTO
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el código del medicamento.");
        string Meds_Code = "";
        Console.ForegroundColor= ConsoleColor.Yellow;
        Meds_Code = Console.ReadLine();

        for (int i = 0; i < MedCode.Length; i++)
        {
            if (MedCode[i] == null)
            {
                MedCode[i] = Meds_Code;
                submenu02 = 1;
                i = MedCode.Length;
            }
            else if (MedCode[i] == Meds_Code)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Este código ya se encuentra en la base de datos");
                submenu02 = 99;
            }
        }
    } while (submenu02 == 0);
    // SOLICITA EL NOMBRE DEL MEDICAMENTO
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el nombre del medicamento.");
        string medicname = "";
        Console.ForegroundColor = ConsoleColor.Yellow;
        medicname = Console.ReadLine();
        if (medicname.Length > 0)
        {
            for (int i = 0; i < MedName.Length; i++)
            {
                if (MedName[i] == null)
                {
                    MedName[i] = medicname;
                    submenu02 = 2;
                    i = MedName.Length;
                }
            }
        }

    } while (submenu02 == 1);
    // SOLICITA LA CANTIDAD DEL MEDICAMENTO
    do
    {
        Console.ForegroundColor= ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese la cantidad del medicamento.");
        int supply = 0;
        try
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            supply = int.Parse(Console.ReadLine());
            for (int i = 0; i < MedCant.Length; i++)
            {
                if (MedCant[i] == 0)
                {
                    MedCant[i] = supply;
                    submenu02 = 3;
                    i = MedCant.Length;
                }
            }
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Esa no es una cantidad válida.");
        }
    } while (submenu02 == 2);
}

void AsignarTratamientoMed()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("A continuación,\nse presentará la lista de los pacientes de la base de datos:");
    Console.WriteLine("Nombre       Cédula       Med1       Med2       Med3       Cantidad Med1       Cantidad Med2       Cantidad Med3\n----------------------------------------------------------------------------------------------------------------\n");
    for (int i = 0; i < nombre.Length; i++)
    {
        Console.WriteLine($"{nombre[i]}       {cedula[i]}       {MedTrata1[i]}       {Medtrata2[i]}       {MedTrata3[i]}       {MedtrataCant1[i]}       {MedtrataCant2[i]}       {MedtrataCant3[i]}");
    }
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------\n");
    int submenu03 = 0;
    // SOLICITA LA CÉDULA DEL PACIENTE QUE SE QUIERE SELECCIONAR
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese la cédula del paciente que desea seleccionar");
        string pacienteID = "";
        int pacienteIndex = 0;
        Console.ForegroundColor= ConsoleColor.Yellow;
        pacienteID = Console.ReadLine();
        for (int i = 0; i < cedula.Length; i++)
        {
            if (pacienteID == cedula[i])
            {
                submenu03 = 1;
                pacienteIndex = i;
                i = cedula.Length;
            }
            else if (i == cedula.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró a algún paciente con ese número de cédula en la base de datos.");
                i = cedula.Length;
            }
        }
    } while (submenu03 == 0);
    // ASIGNACIÓN DE LOS MEDICAMENTOS
    string MyMed01 = "";
    string MyMed02 = "";
    string MyMed03 = "";
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Medicamento       Código       Cantidad\n-----------------------------------------------------------\n");
    for (int i = 0; i < MedName.Length; i++)
    {
        Console.WriteLine($"{MedName[i]}       {MedCode[i]}       {MedCant[i]}");
    }
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el código del medicamento que desea recetar al paciente.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        MyMed01 = Console.ReadLine();
        for (int i = 0; i < MedCode.Length; i++)
        {
            if (MedCode[i] == MyMed01)
            {
                for (int a = 0; a < MedTrata1.Length; a++)
                {
                    if (MedTrata1[i] == null)
                    {
                        MedTrata1[i] = MyMed01;
                        submenu03 = 2;
                        a = MedTrata1.Length;
                    }
                }
                i = MedCode.Length;
            }
            else if (i == MedCode.Length)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("No se encontró ningún medicamento con ese código.");
                i = MedCode.Length;
            }
        }
    } while (submenu03 == 1);
    // SOLICITA EL SEGUNDO MEDICAMENTO A RECETAR
    do
    {
        string MoreMed = "a";
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("¿Desea recetar un segundo medicamento al paciente?       Y/N");
        Console.ForegroundColor = ConsoleColor.Yellow;
        MoreMed = Console.ReadLine();
        string MoreMedUPPER = MoreMed.ToUpper();
        switch (MoreMedUPPER)
        {
            case "Y":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Ingrese el código del segundo medicamento que desea recetar al paciente.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                MyMed02 = Console.ReadLine();

                for (int i = 0; i < MedCode.Length; i++)
                {
                    if (MedCode[i] == MyMed02 && MyMed01 != MyMed02)
                    {
                        for (int a = 0; a < Medtrata2.Length; a++)
                        {
                            if (Medtrata2[i] == null)
                            {
                                Medtrata2[i] = MyMed02;
                                submenu03 = 3;
                                a = Medtrata2.Length;
                            }
                            i = MedCode.Length;
                        }
                    }
                    else if (MyMed01 == MyMed02)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se puede recetar el mismo tipo de medicamento más de una vez.");
                        i = MedCode.Length;
                    }
                    else if (i == MedCode.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se encontró ningún medicamento con ese código.");
                        i = MedCode.Length;
                    }
                }
                    break;
            case "N":
                submenu03 = 99;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ese no es un valor válido. Responda con Y o N");
                break;
        }
    } while (submenu03 == 2);
    // SOLICITA EL TERCER MEDICAMENTO A RECETAR
    do
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Ingrese el código del tercer medicamento que desea recetar al paciente.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        MyMed03 = Console.ReadLine();

        for (int i = 0; i < MedCode.Length; i++)
        {
            if (MedCode[i] == MyMed03 && MyMed03 != MyMed02)
            {
                if (MyMed03 != MyMed01)
                {
                    for (int a = 0; a < Medtrata2.Length; a++)
                    {
                        if (MedTrata3[i] == null)
                        {
                            MedTrata3[i] = MyMed03;
                            submenu03 = 4;
                            a = MedTrata3.Length;
                        }
                    }
                    i = MedCode.Length;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se puede recetar el mismo tipo de medicamento más de una vez.");
                    i = MedCode.Length;
                }
            }
            else if (MyMed03 == MyMed02)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede recetar el mismo tipo de medicamento más de una vez.");
                i = MedCode.Length;
            }
            else if (i == MedCode.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró ningún medicamento con ese código.");
                i = MedCode.Length;
            }
        }

    } while (submenu03 == 3);
}

void Consultas()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("A continuación,\nse presentará las listas de la base de datos:");
    Console.WriteLine("Nombre       Cédula       Teléfono       Sangre       Dirección       Nacimiento\n-------------------------------------------------------------------------------------------------------------\n");
    
    for (int i = 0; i < nombre.Length; i++)
    {
        Console.WriteLine($"{nombre[i]}       {cedula[i]}       {telefono[i]}       {BloodType[i]}       {direccion[i]}       {birthday[i]}");
    }

    Console.WriteLine("Código       Medicamento       Cantidad\n--------------------------------------------------------------------\n");
    for (int i = 0; i < MedName.Length; i++)
    {
        Console.WriteLine($"{MedCode[i]}       {MedName[i]}       {MedCant[i]}");
    }

    Console.WriteLine("Nombre       Cédula       Med1       Med2       Med3       Cantidad Med1       Cantidad Med2       Cantidad Med3\n----------------------------------------------------------------------------------------------------------------\n");
    for (int i = 0; i < nombre.Length; i++)
    {
        Console.WriteLine($"{nombre[i]}       {cedula[i]}       {MedTrata1[i]}       {Medtrata2[i]}       {MedTrata3[i]}       {MedtrataCant1[i]}       {MedtrataCant2[i]}       {MedtrataCant3[i]}");
    }
}