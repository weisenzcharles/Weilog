package org.charles.weilog.domain;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;

import javax.persistence.*;
import java.util.Date;

@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
public class Comment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String authorName;

    private String authorEmail;

    private String authorUrl;

    private String authorIp;
    // 是否被批准
    private boolean approved;
    // 文章 id
    private long postId;
    // 父级 id
    private Long parentId;
    // 评论内容
    private String content;
    // 评论者的 USER AGENT
    private String userAgent;
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}
