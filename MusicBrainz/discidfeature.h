#pragma once
int mb_disc_read_unportable(mb_disc_private* disc, const char* device, unsigned int features);
char* mb_disc_get_default_device_unportable(void);
int  mb_disc_has_feature_unportable(enum discid_feature feature);
