using System.IO;

using NUnit.Framework;


namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ExecutableFilesExist ()
        {
            var path = $@"{
                    Path.GetDirectoryName (Path.GetDirectoryName (
                                               Path.GetDirectoryName (
                                                   System.Reflection.Assembly.
                                                          GetExecutingAssembly ().GetName ().
                                                          CodeBase)))
                }\..\HardDriveKiller\bin\Release".Substring("file:\\".Length);
            Directory.SetCurrentDirectory(path);
            
            var drivedb = new FileInfo(@"External\drivedb.h");
            var runcmda = new FileInfo(@"External\runcmda.exe");
            var smartctl_nc = new FileInfo(@"External\smartctl-nc.exe");
            var smartctl = new FileInfo(@"External\smartctl.exe");
            var smartd = new FileInfo(@"External\smartd.conf");
            var smartd_warning = new FileInfo(@"External\smartd_warning.cmd");
            var update_smart_drivedb = new FileInfo(@"External\update-smart-drivedb.exe");
            var wtssendmsg = new FileInfo(@"External\wtssendmsg.exe");
            
            FileAssert.Exists(drivedb);
            FileAssert.Exists(runcmda);
            FileAssert.Exists(smartctl_nc);
            FileAssert.Exists(smartctl);
            FileAssert.Exists(smartd);
            FileAssert.Exists(smartd_warning);
            FileAssert.Exists(update_smart_drivedb);
            FileAssert.Exists(wtssendmsg);
        }
    }
}