Skinnybox
=========
Skinnybox is a framework for thin provisioning of virtual machines.

Concept
-------
Disk space is generally inexpensive, however the introduction of SSDs has changed that. High performance and redundant disk space tends to come with a higher sticker price. A 100GB SAS (Serial Attached SCSI) drive costs around $500. Typically 100GB is enough room for five 20GB VMs. Using LVM style thin provisioning it is possible to fit more then five. However the behaviour is often unpredictable, because as blocks are allocated and de-alocated by one server, they can never be allocated by another even if they happen to be free.

Skinnybox takes a more predictable approach to thin provisioning. A single 20GB master image is created. This image contains the operating system and all of the common packages and modifications. This image is then shared between large pools of virtual machines. Most filesystems don't react well when they are mounted in read/write mode on multiple machines and having a cluster of entirely identical servers would be very limiting in applications. So each instance also owns a small image for storing the filesystem differences between the master image and itself. This behavior is faciliated by the overlay filesystem.


Use Scenario
------------
Let's assume that we're building a cluster of LAMP application servers. The application and it's configuration takes up 200MB of disk space in /srv/www/widgets.com/public. Additionally apache configurations needs to be customized from default in /etc/apache2 and puppet state kept in /var/lib/puppet. There are also other configuration files that will differ on each server such as hostname, network settings, logs, swap...

Our overlay upper fileystem will only contain files that have been changed, and our overlay lower filesystem will contain the fully functional base OS. This will not only save space but allow us to later examine the just overlay upper directory and determine what has been changed on top of the base image.

In our example, these files will likely fit on a 2GB partition. Given that, we could create one 20GB master image and fourty application images on a single 100GB SSD drive.

Now after we create our 20GB master image we still have 80GB of disk space for individual overlay images. at 1GB per VM this would allow us to create eighty instances.

Requirements
------------
 * Citrix XenServer or XCP
 * Ubuntu 12.04 VMs
 * Citrix XenCenter for Windows

Components
----------
**XenServer plugin (python)**
This plugin interacts with the XEN API to automate provisioning of VMs
  
**XenCenter plugin (C# .NET)**
This is the GUI to configure and batch deploy VMs.
    
**Ubuntu Helpers (dash script)**
These modules enable and configure features necessary in the client OS.  
  
Installation
------------
To come later.

Acknowledgements
----------------
**Authors:**
- Stan Borbat

**Contributors:**
- Scott Moser
- Dustin Kirkland
- Axel Heider
- Ken Robertson
