package org.charles.weilog.domain;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * The type Comment.
 */
@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
public class Comment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;


    // 文章 Id
    private long postId;
    // 父级 Id
    private Long parentId;
    // 评论内容
    private String content;

    private String authorName;

    private String authorEmail;

    private String authorUrl;

    private String authorIp;
    // 是否被批准
    private boolean approved;
    // 评论者的 USER AGENT
    private String userAgent;
    // 用户 Id，如果存在就记录，默认为 0
    private Integer userId;

    @OneToMany(cascade = {CascadeType.PERSIST})
    @JoinColumn(name = "commentId", foreignKey = @ForeignKey(name = "none", value = ConstraintMode.NO_CONSTRAINT))
    private List<CommentMeta> userMetas = new ArrayList<>();

    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}