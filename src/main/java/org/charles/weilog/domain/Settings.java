package org.charles.weilog.domain;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class Settings {
    @Id
    @GeneratedValue
    private Long id;
    private String key;
    private String value;
    private Boolean autoload;


//    private static final String KEY_BLOG_TITLE = "blog.title";
//    private static final String KEY_BLOG_DESCRIPTION = "blog.description";
//    private static final String KEY_BLOG_KEYWORDS = "blog.keywords";
//    private static final String KEY_BLOG_EMAIL = "blog.email";
//    private static final String KEY_BLOG_ICP = "blog.icp";
//    private static final String KEY_BLOG_COPYRIGHT = "blog.copyright";
//    private static final String KEY_BLOG_RECORD = "blog.record";
//    private static final String KEY_BLOG_ICP_URL = "blog.icp.url";
//    private static final String KEY_BLOG_RECORD_URL = "blog.record.url";
//    private static final String KEY_BLOG_RECORD_TEXT = "blog.record.text";
//    private static final String KEY_BLOG_RECORD_IMG = "blog.record.img";
//    private static final String KEY_BLOG_RECORD_IMG_URL = "blog.record.img.url";
//    private static final String KEY_BLOG_RECORD_IMG_WIDTH = "blog.record.img.width";
//    private static final String KEY_BLOG_RECORD_IMG_HEIGHT = "blog.record.img.height";
//    private static final String KEY_BLOG_RECORD_IMG_ALT = "blog.record.img.alt";
//    private static final String KEY_BLOG_RECORD_IMG_TITLE = "blog.record.img.title";
//    private static final String KEY_BLOG_RECORD_IMG_LINK = "blog.record.img.link";
//    private static final String KEY_BLOG_RECORD_IMG_LINK_TEXT = "blog.record.img.link.text";
//    private static final String KEY_BLOG_RECORD_IMG_LINK_TITLE = "blog.record.img.link.title";
//    private static final String KEY_BLOG_RECORD_IMG_LINK_TARGET = "blog.record.img.link.target";
}
