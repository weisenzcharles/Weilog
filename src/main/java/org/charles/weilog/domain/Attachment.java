package org.charles.weilog.domain;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "attachments")
public class Attachment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private Long postId;
    // 文件类型
    private String mimeType;

    private String name;
    // 别名
    private String alias;

    private String path;

    private Boolean deleted;
    // 上传用户
    private Long userId;
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}