OUTPUTS = Uname.NET.*/bin Uname.NET.*/obj Uname.NET/bin Uname.NET/obj

.PHONY: all

# General use

all: all-online

all-online:
	$(MAKE) -C tools invoke-build

clean:
	rm -rf $(OUTPUTS)

# This makefile is just a wrapper for tools scripts.
